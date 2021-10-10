package no.hvl.dat250.gruppe5.voteapp.repository;

import java.util.Optional;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import no.hvl.dat250.gruppe5.voteapp.models.VoterProfile;

@Repository
public interface VoterProfileRepository extends CrudRepository<VoterProfile, Long> {

    Optional<VoterProfile> findVoterByEmail(String email);

    Optional<VoterProfile> findByUsername(String username);
}