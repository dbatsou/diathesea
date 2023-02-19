import { makeAutoObservable } from "mobx";
import agent from "../api/agent";
import { StateFormFormatted } from "../models/state";

export default class StateStore {
  loadingInitial = false;
  states: StateFormFormatted[] = [];
  constructor() {
    makeAutoObservable(this);
  }

  loadStates = async () => {
    try {
      this.setLoadingInitial(true);

      const states = await agent.States.list();
      states.forEach((value) => {
        this.states.push({
          key: value.StateId,
          text: value.StateName,
          value: value.StateName,
          stateid: value.StateId, //not sure why the key prop always comes w/ 0 and the stateid with the right value TODO check
          parentstateid: value.ParentStateID,
        });
        this.setLoadingInitial(false);
      });
      this.setLoadingInitial(false);
    } catch (error) {
      console.log(error);
    }
  };

  setLoadingInitial(state: boolean) {
    this.loadingInitial = state;
  }
}
