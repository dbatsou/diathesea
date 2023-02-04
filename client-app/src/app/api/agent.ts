import axios, { AxiosResponse } from "axios";
import { AuthenticationModel } from "../models/authenticationModel";
import { State } from "../models/state";
import { StateEntry } from "../models/stateEntry";

// const sleep = (delay: number) => {
//   return new Promise((resolve) => {
//     setTimeout(resolve, delay);
//   });
// };

axios.defaults.baseURL = "http://localhost:5000/api";
axios.defaults.withCredentials = true;

// axios.interceptors.response.use(async (response) => {
//   try {
//     await sleep(1000);
//     return response;
//   } catch (error) {
//     console.log(error);
//     return await Promise.reject(error);
//   }
// });

const responseBody = <T>(response: AxiosResponse<T>) => response.data;
const requests = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: {}) =>
    axios.post<T>(url, body).then(responseBody),
  put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
  del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};

const States = {
  list: () => requests.get<State[]>("/state"),
};

const stateEntryUri = "stateEntry";
const StateEntries = {
  list: () => requests.get<StateEntry[]>(`/${stateEntryUri}`),
  delete: (id: number) => axios.delete<void>(`/${stateEntryUri}/${id}`),
  details: (id: number) => axios.get<StateEntry>(`/${stateEntryUri}/${id}`),
  create: (stateEntry: StateEntry) =>
    axios.post<void>(`/${stateEntryUri}`, stateEntry),
  update: (stateEntry: StateEntry) =>
    axios.put<void>(`/${stateEntryUri}/${stateEntry.StateEntryId}`, stateEntry),
};

const userUri = "user";
const User = {
  register: (authModel: AuthenticationModel) =>
    axios.post<void>(`/${userUri}/register`, authModel),

  login: (authModel: AuthenticationModel) =>
    axios.post<void>(`/${userUri}`, authModel),
  logout: () => axios.post<void>(`/${userUri}/logout`),
};

const agent = {
  StateEntries,
  States,
  User,
};

export default agent;
