import { canApproveFidgets } from "../actions/auth";

export default {
    ["LOGIN_SUCCESS"](state) {
        state.canApproveFidgets = canApproveFidgets();
    },
    ["LOGIN_ERROR"](state) {
        state.loginError = "Invalid username or password.";
    },
}