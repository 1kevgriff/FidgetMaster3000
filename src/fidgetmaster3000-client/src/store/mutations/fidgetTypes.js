export default {
    ["LOAD_FIDGET_TYPES_SUCCESS"](state, data){
        state.fidgetTypes = data;
    },
    ["DELETE_FIDGET_ERROR"](state, data){
        state.error.deleteFidget = `There was an error deleting ${data.typeName}.`;
        state.snackbar.showDeleteFidgetError = true;
    }
}