import { makeAutoObservable } from "mobx";
import agent from "../api/agent";
import { AuthenticationModel } from "../models/authenticationModel";

export default class AuthStore {
  isSubmitting = false;
  isLoggedIn = false;
  authModel: AuthenticationModel = {
    Username: "",
    Password: "",
  };

  constructor() {
    makeAutoObservable(this);
  }

  setIsLoggedIn(state: boolean) {
    this.isLoggedIn = state;
  }

  register = (authModel: AuthenticationModel) => {
    try {
      agent.User.register(authModel)
        .then((response) => {})
        .catch((error) => {});
    } catch {}
  };

  login = (authModel: AuthenticationModel) => {
    agent.User.login(authModel)
      .then((response) => {
        if (response.status == 200) {
          this.setIsLoggedIn(true);
        }
      })
      .catch((error) => {});
  };
}
