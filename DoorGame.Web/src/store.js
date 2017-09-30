import { createStore } from 'redux'
import { reducers } from './reducers'

var initial = {
    boxes: { init: false, colors: [] },
}

export function configureStore(initialState = initial) {
    const store = createStore(
        reducers,
        initialState
    )
    return store;
};

export const store = configureStore(); 