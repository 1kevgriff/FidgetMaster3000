import axios from "axios";
import { setIdToken } from "./auth";

import router from "../../router";

export default {
    login({ commit }, loginData) {
        var api = "/authenticate";

        axios.post(api, loginData)
            .then((res) => {
                setIdToken(res.data);
                commit("LOGIN_SUCCESS", res.data);

                router.push({ name: "home" });
            }, () => {
                commit("LOGIN_ERROR");
            })
    }
}