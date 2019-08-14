export default {
    ["LOGIN_SUCCESS"]() {
    },
    ["LOGIN_ERROR"](state) {
        state.loginError = "Invalid username or password.";
    },
}