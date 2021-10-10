package no.hvl.dat250.gruppe5.voteapp.services;

import no.hvl.dat250.gruppe5.voteapp.models.VoterProfile;
import no.hvl.dat250.gruppe5.voteapp.repository.VoterProfileRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.util.List;
import java.util.Objects;
import java.util.Optional;

@Service
public class VoterProfileServices {

    private final VoterProfileRepository voterProfileRepository;

    @Autowired
    public VoterProfileServices(VoterProfileRepository voterProfileRepository) {
        this.voterProfileRepository = voterProfileRepository;
    }

    public List<VoterProfile> getVoters() {
        return (List<VoterProfile>) voterProfileRepository.findAll();
    }

    public Optional<VoterProfile> getVoter(Long voterID) {
        return voterProfileRepository.findById(voterID);
    }

    public void addNewVoter(VoterProfile voter) {
        Optional<VoterProfile> voterByEmail = voterProfileRepository.findVoterByEmail(voter.getEmail());
        if (voterByEmail.isPresent()){
            throw new IllegalStateException("email taken");
        }
        voterProfileRepository.save(voter);
    }

    public void deleteVoter(Long voterID) {
        if (!voterProfileRepository.existsById(voterID)){
            throw new IllegalStateException("voter " + voterID + " does not exist!");
        }
        voterProfileRepository.deleteById(voterID);
    }

    @Transactional
    public void updateVoter(Long voterId, String username, String email, String fName, String lName) {
        VoterProfile voter = voterProfileRepository.findById(voterId).orElseThrow(() ->
                new IllegalStateException("voter " + voterId + " does not exist!"));

        if (username != null && !Objects.equals(voter.getUsername(), username)) {
            voter.setUsername(username);
        }
        if (fName != null && !Objects.equals(voter.getFirstName(), fName)) {
            voter.setFirstName(fName);
        }
        if (lName != null && !Objects.equals(voter.getLastName(), lName)) {
            voter.setLastName(lName);
        }
        if (email != null && !Objects.equals(voter.getEmail(), email)) {
            Optional<VoterProfile> voterByEmail = voterProfileRepository.findVoterByEmail(email);
            if (voterByEmail.isPresent()){
                throw new IllegalStateException("email taken");
            }
            voter.setEmail(email);
        }
    }
}
