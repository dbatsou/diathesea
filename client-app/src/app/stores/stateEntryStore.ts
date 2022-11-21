import { makeAutoObservable, makeObservable } from "mobx";
import agent from "../api/agent";
import { StateEntry } from "../models/stateEntry";

export default class StateEntryStore {
  loadingInitial = true;
  isSubmitting = false;
  editMode = false;
  addMode = false;
  stateEntries: StateEntry[] = [];
  selectedStateEntry: StateEntry | undefined = undefined;

  constructor() {
    makeAutoObservable(this);
  }

  handleSelectStateEntry = (stateEntryId: number) => {
    this.selectedStateEntry = this.stateEntries.find(
      (x) => x.StateEntryId === stateEntryId
    );
  };

  handleFormOpen = (id?: number) => {
    id ? this.handleSelectStateEntry(id) : this.handleCancelSelectStateEntry();
    this.setEditMode(true);
  };

  handleFormClose = () => {
    this.setEditMode(false);
  };

  handleCancelSelectStateEntry = () => {
    this.selectedStateEntry = undefined;
    this.setEditMode(false);
    this.setAddMode(false);
  };

  createOrEditStateEntry = (stateEntry: StateEntry) => {
    console.log("from createOrEditStateEntry(): ", stateEntry);
    try {
      if (stateEntry.StateEntryId) {
        console.log("edit");

        agent.StateEntries.update(stateEntry)
          .then((response) => {
            if (response.status === 200) this.loadStateEntries();
          })
          .catch((error) => {
            console.log(error);
          });
      } else {
        console.log("create");
        agent.StateEntries.create(stateEntry)
          .then((response) => {
            if (response.status === 201) this.loadStateEntries();
          })
          .catch((error) => {
            console.log(error);
          });
      }
      this.setEditMode(false);
      this.setAddMode(false);
    } catch (error) {
      console.log(error);
    }
  };

  handleDeleteStateEntry = async (id: number) => {
    this.setIsSubmitting(true);
    try {
      agent.StateEntries.delete(id).then(async (resp) => {
        await this.loadStateEntries();
        this.setIsSubmitting(false);
      });
    } catch (error) {
      console.log(error);
    }
  };

  loadStateEntries = async () => {
    try {
      const entries = await agent.StateEntries.list();
      this.stateEntries = entries;
      this.setLoadingInitial(false);
    } catch (error) {
      this.setLoadingInitial(false);
      console.log(error);
    }
  };

  handleNewMode = () => {
    this.setAddMode(true);
  };
  setLoadingInitial(state: boolean) {
    this.loadingInitial = state;
  }

  setEditMode(state: boolean) {
    this.editMode = state;
  }

  setIsSubmitting(state: boolean) {
    this.isSubmitting = state;
  }

  setAddMode(state: boolean) {
    this.addMode = state;
  }
}
