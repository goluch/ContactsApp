import { type InjectionKey } from 'vue'
import { createStore, useStore as baseUseStore, Store } from 'vuex'

// define your typings for the store state
export interface State {
    contactsList: any
    loading: boolean
    loggedIn: boolean
    loginMode: boolean
}

// define injection key
export const key: InjectionKey<Store<State>> = Symbol()

export const store = createStore<State>({
    state: {
        loading: false,
        loggedIn: false,
        loginMode: false,
    },
    mutations: {
        setAllDisplaysNull(state: State) {
            state.loggedIn = false
            state.loginMode = false
        },
        setContactsList(state: State, value: any) {
            state.contactsList = value;
        },
        setLoading(state: State, value: boolean) {
            state.loading = value;
        },
        setloggedIne(state: State, value: boolean) {
            state.loggedIn = value;
        },
        setLoginMode(state: State, value: boolean) {
            state.loginMode = value;
        },
    },
})

// define your own `useStore` composition function
export function useStore() {
    return baseUseStore(key)
}