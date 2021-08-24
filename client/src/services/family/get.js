import { commonService } from "../common";
import { familyEndpoint } from "./endpoints";

export const get = (userId) => commonService.get(`${familyEndpoint}/${userId}`)