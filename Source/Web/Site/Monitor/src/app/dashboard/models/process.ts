export interface Process {
    pid: string;
    name: string;
    status: string;
    user: string;
    workingSet: number;
}
