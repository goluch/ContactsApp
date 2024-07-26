import { type InjectionKey } from 'vue'
import { createStore, useStore as baseUseStore, Store } from 'vuex'

// define your typings for the store state
export interface State {
    contactsList: any
    loading: boolean
    loggedIn: boolean
    registrationMode: boolean
    loginMode: boolean
    contactsMode: boolean
    contactDetails: boolean
    contactAdd: boolean
    contactEdit: boolean
    contactDelete: boolean
    msg: string,
}

// define injection key
export const key: InjectionKey<Store<State>> = Symbol()

export const store = createStore<State>({
    state: {
        contactsList: null,
        loading: false,
        loggedIn: false,
        registrationMode: false,
        loginMode: false,
        contactsMode: true,
        contactcontactDetails: false,
        contactcontactAdd: false,
        contactcontactedit: false,
        contactcontactDelete: false,
        msg: "",
    },
    mutations: {
        setAllDisplaysNull(state: State) {
            state.registrationMode = false
            state.loginMode = false
            state.contactsMode = false
            state.contactDetails = false
            state.contactAdd = false
            state.contactEdit = false
            state.contactDelete = false
            state.msg = "";
        },
        setContactsList(state: State, value: any) {
            state.contactsList = value;
        },
        setLoading(state: State, value: boolean) {
            state.loading = value;
        },
        setloggedIn(state: State, value: boolean) {
            state.loggedIn = value;
        },
        setRegistrationMode(state: State, value: boolean) {
            state.registrationMode = value;
        },
        setLoginMode(state: State, value: boolean) {
            state.loginMode = value;
        },
        setContactsMode(state: State, value: boolean) {
            state.contactsMode = value;
        },
        setContactsDetails(state: State, value: boolean) {
            state.contactDetails = value;
        },
        setContactsAdd(state: State, value: boolean) {
            state.contactAdd = value;
        },
        setContactsEdit(state: State, value: boolean) {
            state.contactEdit = value;
        },
        setContactsDelete(state: State, value: boolean) {
            state.contactDelete = value;
        },
        setMsg(state: State, value: string) {
            state.msg = value;
        },
        addMsg(state: State, value: string) {
            state.msg += value;
        },
    },
})

// define your own `useStore` composition function
export function useStore() {
    return baseUseStore(key)
}