/*
    Store that holds other stores
*/
import { createContext, useContext } from "react";
import ActivityEntryStore from "./activityEntryStore";

interface Store {
  activityEntryStore: ActivityEntryStore;
}

export const store: Store = {
  activityEntryStore: new ActivityEntryStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
