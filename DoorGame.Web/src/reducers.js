import {
    applyMiddleware,
    combineReducers,
    createStore,
} from 'redux';


var boxesInit = {
    init: false,
    colors: [],
    rows: 0,
    cols: 0
}

export const boxes = (state = boxesInit, action) => {
    switch (action.type) {        
        case 'INIT':
            var newState = Object.assign({}, state,
                {
                    init: true,
                    colors: action.Colors,
                    rows: action.Rows,
                    cols: action.Cols
                });
            return newState;
        case 'COLOR_CHANGED':
            var newState = Object.assign({}, state,
                {
                    colors: state.colors.slice()
                });
            newState.colors[action.BoxNum] = action.Color;
            return newState;
        case 'COLOR_CHANGE_FAILED':
            console.log('color change fail');
            return state;
        default:
            if (!action.type.startsWith('@@redux')) {
                console.log('action unhandled:', action.type);
            }
            return state;
    }
};

export const reducers = combineReducers({
    boxes
});