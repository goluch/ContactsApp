import { type InjectionKey } from 'vue'
import { createStore, useStore as baseUseStore, Store } from 'vuex'
import { Contact } from "./common/types";

// define your typings for the store state
export interface State {
    contactsList: [Contact]
    suportedCategoriesList: [string]
    suportedBusinessSubcategoriesList: [string]
    loading: boolean
    loggedIn: boolean
    token: string
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
        suportedCategoriesList: null,
        suportedBusinessSubcategoriesList: null,
        loading: false,
        loggedIn: false,
        loggedInToken: null,
        registrationMode: false,
        loginMode: true,
        contactsMode: false,
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
        setContactsList(state: State, value: [Contact]) {
            state.contactsList = value;
        },
        setSuportedCategoriesList(state: State, value: [string]) {
            state.suportedCategoriesList = value;
        },
        setSuportedBusinessSubcategoriesList(state: State, value: [string]) {
            state.suportedBusinessSubcategoriesList = value;
        },
        setLoading(state: State, value: boolean) {
            state.loading = value;
        },
        setToken(state: State, value: string) {
            state.token = value;
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