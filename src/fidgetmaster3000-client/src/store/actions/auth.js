import decode from 'jwt-decode';
import axios from 'axios';

const ID_TOKEN_KEY = "access_token";
const LOGGED_IN_AS_KEY = "logged_in_as";

export function requireAuth(to, from, next) {
    if (!isLoggedIn()) {
        next({
            name: 'login',
            query: { redirect: to.fullPath }
        });
    } else {
        next();
    }
}

export function isLoggedIn() {
    const idToken = getIdToken();
    return !!idToken && !isTokenExpired(idToken);
}

export function setHeader() {
    axios.defaults.headers.common = {
        'Authorization': 'bearer ' + getIdToken()
    };
}

export function getIdToken() {
    return localStorage.getItem(ID_TOKEN_KEY);
}

export function setIdToken(token) {
    localStorage.setItem(ID_TOKEN_KEY, token.jwt);
    localStorage.setItem(LOGGED_IN_AS_KEY, token.userName);

    setHeader();
}

export function getLoggedInAs() {
    if (isLoggedIn()) {
        return localStorage.getItem(LOGGED_IN_AS_KEY);
    } else {
        localStorage.removeItem(ID_TOKEN_KEY);
        localStorage.removeItem(LOGGED_IN_AS_KEY);
        return undefined;
    }
}

export function logOut() {
    localStorage.removeItem(ID_TOKEN_KEY);
    localStorage.removeItem(LOGGED_IN_AS_KEY);
}

function getTokenExpirationDate(encodedToken) {
    const token = decode(encodedToken);
    if (!token.exp) { return null; }

    const date = new Date(0);
    date.setUTCSeconds(token.exp);

    return date;
}

function isTokenExpired(token) {
    const expirationDate = getTokenExpirationDate(token);
    return expirationDate < new Date();
}