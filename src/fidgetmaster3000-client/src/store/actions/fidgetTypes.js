import axios from "axios";

export default {
    loadFidgetTypes({commit}){
        var api = "/api/fidgetTypes";

        axios.get(api).then((res)=> {
            commit("LOAD_FIDGET_TYPES_SUCCESS", res.data);
        });
    }
}