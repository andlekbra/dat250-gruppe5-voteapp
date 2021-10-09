package no.hvl.dat250.gruppe5.voteapp.repository;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import no.hvl.dat250.gruppe5.voteapp.models.PollTemplate;

@Repository
public interface PollTemplateRepository extends CrudRepository<PollTemplate, Long> {

}
