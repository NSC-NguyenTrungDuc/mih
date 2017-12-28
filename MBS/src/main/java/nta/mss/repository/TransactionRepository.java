package nta.mss.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import nta.mss.entity.Transaction;

@Repository
public interface TransactionRepository extends JpaRepository<Transaction, String>{
	
	@Query("SELECT t FROM Transaction t WHERE t.id = ?")
	public List<Transaction> findById(Integer id);
	
}
