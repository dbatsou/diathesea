import axios, { AxiosResponse } from "axios";
import { ActivityEntry } from "../models/activityentry";
import { State } from "../models/state";
import { StateEntry } from "../models/stateEntry";

// const sleep = (delay: number) => {
//   return new Promise((resolve) => {
//     setTimeout(resolve, delay);
//   });
// };

axios.defaults.baseURL = "http://localhost:5000/api";

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

const activityEntryUri = "activityEntry";
const ActivityEntries = {
  list: () => requests.get<ActivityEntry[]>(`/${activityEntryUri}`),
  details: (id: string) =>
    requests.get<ActivityEntry>(`/${activityEntryUri}/${id}`),
  create: (activityEntry: ActivityEntry) =>
    axios.post<void>(`/${activityEntryUri}}`, activityEntry),
  update: (activityEntry: ActivityEntry) =>
    axios.put<void>(
      `/${activityEntryUri}/${activityEntry.ActivityEntryId}`,
      activityEntry
    ),
  delete: (id: string) => axios.delete<void>(`/${activityEntryUri}/${id}`),
};

const States = {
  list: () => requests.get<State[]>("/state"),
};

const stateEntryUri = "stateEntry";
const StateEntries = {
  list: () => requests.get<StateEntry[]>(`/${stateEntryUri}`),
  delete: (id: number) => axios.delete<void>(`/${stateEntryUri}/${id}`),
  create: (stateEntry: StateEntry) =>
    axios.post<void>(`/${stateEntryUri}`, stateEntry),
  update: (stateEntry: StateEntry) =>
    axios.put<void>(`/${stateEntryUri}/${stateEntry.StateEntryId}`, stateEntry),
};

const agent = {
  ActivityEntries,
  StateEntries,
  States,
};

export default agent;
