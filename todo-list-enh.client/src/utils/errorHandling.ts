import axios from 'axios';

const errorMessages: Record<number, string> = {
    400: "����������� �����.",
    401: "��������������� ������.",
    403: "� ��� ����������� ����.",
    404: "������ �� ��������.",
    500: "�������� ������� �������.",
};

export const handleApiError = (error: unknown) => {
    if (axios.isAxiosError(error) && error.response) {
        return errorMessages[error.response.status] || "������� ������� �������.";
    }
    return "������� ����� ��� ������ �����������.";
};