package no.hvl.dat250.gruppe5.voteapp.repository;

import no.hvl.dat250.gruppe5.voteapp.models.IoTDevice;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface IoTDeviceRepository extends CrudRepository<IoTDevice, Long> {

}
