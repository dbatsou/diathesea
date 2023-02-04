/*
    Store that holds other stores
*/
import { createContext, useContext } from "react";
import AuthStore from "./authStore";
import StateEntryStore from "./stateEntryStore";
import StateStore from "./stateStore";

interface Store {
  stateEntryStore: StateEntryStore;
  stateStore: StateStore;
  authStore: AuthStore;
}

export const store: Store = {
  stateEntryStore: new StateEntryStore(),
  stateStore: new StateStore(),
  authStore: new AuthStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
