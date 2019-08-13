import axios from "axios";

export default {
    loadFidgetTypes({ commit }) {
        var api = "/api/fidgetTypes";

        axios.get(api).then((res) => {
            commit("LOAD_FIDGET_TYPES_SUCCESS", res.data);
        });
    },
    saveFidgetType({ dispatch }, item) {
        var api = "/api/fidgetTypes";

        axios.post(api, item).then(()=>{
            dispatch("loadFidgetTypes");
        });
    }
}