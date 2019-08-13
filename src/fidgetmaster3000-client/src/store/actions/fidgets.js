import axios from "axios";

export default {
    loadFidgets({ commit }) {
        var api = "/api/fidgets";

        axios.get(api).then((res) => {
            commit("LOAD_FIDGET_SUCCESS", res.data);
        });
    },
    saveFidget({ dispatch }, item) {
        var api = "/api/fidgets";

        axios.post(api, item).then(()=>{
            dispatch("loadFidgets");
        });
    }
}