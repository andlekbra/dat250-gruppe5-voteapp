package no.hvl.dat250.gruppe5.voteapp.repository;

import no.hvl.dat250.gruppe5.voteapp.models.PollTemplate;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public interface PollTemplateRepository extends CrudRepository<PollTemplate, Long> {

    Optional<PollTemplate> findById(Long id);

    //Iterable<PollTemplate> findAllByVoter(VoterProfile voter);




}
