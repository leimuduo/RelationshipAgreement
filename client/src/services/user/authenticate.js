import { commonService } from "../common";
import { userEndpoint } from "./endpoints";

export const authenticate = (data) => commonService.post(
  `${userEndpoint}/authenticate`,
  data
)