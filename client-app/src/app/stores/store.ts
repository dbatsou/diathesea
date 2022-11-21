/*
    Store that holds other stores
*/
import { createContext, useContext } from "react";
import StateEntryStore from "./stateEntryStore";
import StateStore from "./stateStore";

interface Store {
  stateEntryStore: StateEntryStore;
  stateStore: StateStore;
}

export const store: Store = {
  stateEntryStore: new StateEntryStore(),
  stateStore: new StateStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
