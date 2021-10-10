package no.hvl.dat250.gruppe5.voteapp.models;

import lombok.Getter;
import lombok.RequiredArgsConstructor;
import lombok.Setter;
import lombok.ToString;

import javax.persistence.*;

import com.fasterxml.jackson.annotation.JsonIdentityInfo;
import com.fasterxml.jackson.annotation.JsonIdentityReference;
import com.fasterxml.jackson.annotation.ObjectIdGenerators;

import java.util.List;
import java.util.Objects;

@Getter
@Setter
@ToString
@RequiredArgsConstructor
@Entity
@JsonIdentityInfo(generator = ObjectIdGenerators.PropertyGenerator.class, property = "id")
public class PollTemplate {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private long id;
    private String title;
    private String question;
    private String redAnswer;
    private String greenAnswer;

    public PollTemplate(String title, String question, String redAnswer, String greenAnswer) {

        this.title = title;
        this.question = question;
        this.redAnswer = redAnswer;
        this.greenAnswer = greenAnswer;

    }

    @ManyToOne
    private VoterProfile voter;

    @OneToMany
    @ToString.Exclude
    @JsonIdentityReference(alwaysAsId = true)
    private List<Poll> polls;

    @Override
    public boolean equals(Object o) {
        if (this == o)
            return true;
        if (o == null || getClass() != o.getClass())
            return false;
        PollTemplate that = (PollTemplate) o;
        return Objects.equals(id, that.id);
    }

    @Override
    public int hashCode() {
        return 0;
    }
}
