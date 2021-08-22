import { commonService } from "../common";
import { userEndpoint } from "./endpoints";

export const update = (userId, data) => commonService.put(
  `${userEndpoint}/${userId}`,
  data
)