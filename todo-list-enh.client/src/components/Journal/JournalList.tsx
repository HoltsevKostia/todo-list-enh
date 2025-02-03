import React from "react";
import { useJournals } from "../../hooks/useJournals/useJournalList";

const JournalList: React.FC = () => {
    const { journals, loading, error, handleDelete } = useJournals();

    if (loading) return <div>������������...</div>;
    if (error) return <div>�������: {error}</div>;

    return (
        <div>
            <h1>�� �������</h1>
            <ul>
                {journals.map((journal) => (
                    <li key={journal.id}>
                        {journal.title}
                        <button onClick={() => handleDelete(journal.id.toString())}>��������</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default JournalList;
