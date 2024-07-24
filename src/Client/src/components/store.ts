import { type InjectionKey } from 'vue'
import { createStore, Store } from 'vuex'

// define your typings for the store state
export interface State {
    loggedIn: boolean
}

// define injection key
export const key: InjectionKey<Store<State>> = Symbol()

export const store = createStore<State>({
    state: {
        loggedIn: false
    },
    mutations: {
        setAllDisplaysNull(state: State) {
            state.loggedIn = false
        },
    },
})