package no.hvl.dat250.gruppe5.voteapp.services;

import lombok.Data;
import no.hvl.dat250.gruppe5.voteapp.models.PollTemplate;
import no.hvl.dat250.gruppe5.voteapp.repository.PollTemplateRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Optional;

@Data
@Service
public class PollTemplateService {


    private final PollTemplateRepository pollTemplateRepository;

    @Autowired
    public PollTemplateService(PollTemplateRepository pollTemplateRepository) {
        this.pollTemplateRepository = pollTemplateRepository;
    }

    public Iterable<PollTemplate> getAllTemplates(){
        return pollTemplateRepository.findAll();
    }
/*
    public Iterable<PollTemplate> getAllTemplatesByVoter(VoterProfile voter){
        return pollTemplateRepository.findAllByVoter(voter);
    }
*/
    public Optional<PollTemplate> getPollTemplateById(Long pollTempId){
        return pollTemplateRepository.findById(pollTempId);

    }

    public void  addNewPollTemplate(PollTemplate pollTemplate){
        pollTemplateRepository.save(pollTemplate);
    }

    public void deletePollTemplate(Long pollTempId){
        pollTemplateRepository.deleteById(pollTempId);
    }


}

