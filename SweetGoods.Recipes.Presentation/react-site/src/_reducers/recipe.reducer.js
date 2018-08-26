import {recipeConstants} from '../_constants';

export function recipes(state = {}, action){
    switch (action.tye){
        case recipeConstants.CREATE_REQUEST:
            return {creating: true};
        case recipeConstants.CREATE_SUCCESS:
            return {
                ...state,
                items: state.concat([action.data])
            };
        case recipeConstants.CREATE_FAILURE:
            return {};
        case recipeConstants.UPDATE_RQUEST:
            return{
                ...state,
                items: state.items.map(recipe =>
                    recipe.id === action.id
                    ? {...recipes, updating: true}
                    : recipes
                )
            }
        case recipeConstants.UPDATE_SUCCESS:
            return{
                
            }
        default: 
            return state
    }
}