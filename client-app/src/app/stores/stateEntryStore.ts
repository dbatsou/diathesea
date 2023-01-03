import { makeAutoObservable, makeObservable } from "mobx";
import agent from "../api/agent";
import { StateEntry } from "../models/stateEntry";

export default class StateEntryStore {
  loadingInitial = false;
  isSubmitting = false;
  stateEntries: StateEntry[] = [];

  constructor() {
    makeAutoObservable(this);
  }

  createOrEditStateEntry = (stateEntry: StateEntry) => {
    try {
      if (stateEntry.StateEntryId) {
        agent.StateEntries.update(stateEntry)
          .then((response) => {
            if (response.status === 200) this.loadStateEntries();
          })
          .catch((error) => {});
      } else {
        agent.StateEntries.create(stateEntry)
          .then((response) => {
            if (response.status === 201) this.loadStateEntries();
          })
          .catch((error) => {});
      }
    } catch (error) {}
  };

  handleDeleteStateEntry = async (id: number) => {
    this.setIsSubmitting(true);
    try {
      agent.StateEntries.delete(id).then(async (resp) => {
        await this.loadStateEntries();
        this.setIsSubmitting(false);
      });
    } catch (error) {}
  };

  loadStateEntries = async () => {
    try {
      const entries = await agent.StateEntries.list();
      this.setStateEntries(entries);
    } catch (error) {}
  };

  loadStateEntry = async (id: number) => {
    let entry = this.getStateEntry(id);
    if (entry) {
      return entry;
    } else
      try {
        let entry = await agent.StateEntries.details(id);
        return entry.data;
      } catch (error) {}
  };

  setLoadingInitial(state: boolean) {
    this.loadingInitial = state;
  }

  setIsSubmitting(state: boolean) {
    this.isSubmitting = state;
  }

  setStateEntries(stateEntries: StateEntry[]) {
    this.stateEntries = stateEntries;
  }

  getStateEntry(id: number) {
    return this.stateEntries.find((x) => x.StateEntryId === id)!;
  }
}
