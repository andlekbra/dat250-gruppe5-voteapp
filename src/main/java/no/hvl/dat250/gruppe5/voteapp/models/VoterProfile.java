package no.hvl.dat250.gruppe5.voteapp.models;

import lombok.*;
import org.hibernate.Hibernate;

import javax.persistence.*;
//import java.util.HashSet;
//import java.util.Hashtable;
import java.util.Objects;
import java.util.Set;

@Getter
@Setter
@RequiredArgsConstructor
@ToString
@Entity
public class VoterProfile {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)

    private long id;
    private String userName;
    private String email;
    private String firstName;
    private String lastName;
    private String password;

    @OneToMany
    @ToString.Exclude
    private Set<PollTemplate> pollTemplates;

    @Override
    public boolean equals(Object o) {
        if (this == o)
            return true;
        if (o == null || Hibernate.getClass(this) != Hibernate.getClass(o))
            return false;
        VoterProfile that = (VoterProfile) o;
        return Objects.equals(id, that.id);
    }

    @Override
    public int hashCode() {
        return 0;
    }
}
