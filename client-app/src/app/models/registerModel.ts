import { AuthenticationModel } from "./authenticationModel";

export interface RegisterModel extends AuthenticationModel {
  RepeatPassword?: string;
}
