import { recipeConstants } from "../_constants";
import { recipeService } from "../_services";
import { alertActions } from "./";
import { history } from "../_helpers";

export const recipeActions = {
  create,
  update,
  getAll,
  get,
  delete: _delete
};

function create(name, description) {
  return dispatch => {
    dispatch(request({ name, description }));

    recipeService.create(name, description).then(
      recipe => {
        dispatch(success(recipe));
        history.push("/recipe");
        dispatch(alertActions.success("Receita criada"));
      },
      error => {
        dispatch(failure(error));
        dispatch(alertActions.error(error));
      }
    );
  };

  function request(recipe) {
    return { type: recipeConstants.CREATE_REQUEST, recipe };
  }
  function success(recipe) {
    return { type: recipeConstants.CREATE_SUCCESS, recipe };
  }
  function failure(error) {
    return { type: recipeConstants.CREATE_FAILURE, error };
  }
}

function update(recipe) {
  return dispatch => {
    dispatch(request(recipe));

    recipeService.update(recipe).then(
      recipe => {
        dispatch(success(recipe));
        history.push("/recipe");
        dispatch(alertActions.success("Receita atualizada"));
      },
      error => {
        dispatch(failure(error));
        dispatch(alertActions.error(error));
      }
    );
  };

  function request(recipe) {
    return { type: recipeConstants.UPDATE_REQUEST, recipe };
  }
  function success(recipe) {
    return { type: recipeConstants.UPDATE_SUCCESS, recipe };
  }
  function failure(error) {
    return { type: recipeConstants.UPDATE_FAILURE, error };
  }
}

function getAll() {
  return dispatch => {
    dispatch(request());

    recipeService.getAll().then(
      recipes => dispatch(success(recipes)),
      error => {
        dispatchEvent(failure(error));
        dispatch(alertActions.error(error));
      }
    );
  };

  function request() {
    return { type: recipeConstants.GETALL_REQUEST };
  }
  function success(recipes) {
    return { type: recipeConstants.GETALL_SUCCESS, recipes };
  }
  function failure(error) {
    return { type: recipeConstants.GETALL_FAILURE, error };
  }
}

function get(id) {
  return dispatch => {
    dispatch(request(id));

    recipeService.get(id).then(
      recipe => dispatch(success(recipe)),
      error => {
        dispatch(failure(recipe));
        dispatch(alertActions.error(error));
      }
    );
  };

  function request(id) {
    return { type: recipeConstants.GET_REQUEST, id };
  }
  function success(recipe) {
    return { type: recipeConstants.GET_SUCCESS, recipe };
  }
  function failure(error) {
    return { type: recipeConstants.GET_FAILURE, error };
  }
}

function _delete(id) {
  return dispatch => {
    dispatch(request(id));

    recipeService.delete(id).then(
      recipe => {
        dispatch(success(id));
      },
      error => {
        dispatch(failure(id, error));
      }
    );
  };

  function request(id) {
    return { type: recipeConstants.DELETE_REQUEST, id };
  }
  function success(id) {
    return { type: recipeConstants.DELETE_SUCCESS, id };
  }
  function failure(id, error) {
    return { type: recipeConstants.DELETE_FAILURE, id, error };
  }
}
