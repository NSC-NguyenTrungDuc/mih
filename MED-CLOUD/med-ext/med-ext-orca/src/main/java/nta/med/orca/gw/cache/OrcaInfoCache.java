package nta.med.orca.gw.cache;

import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ConcurrentMap;

public class OrcaInfoCache {
	
	// ConcurrentMap<hosp_code, ConcurrentMap<patient_id, hash_value>>
	public static ConcurrentMap<String, ConcurrentMap<String, Integer>> patientListCache = new ConcurrentHashMap<>();
	
	// ConcurrentMap<hosp_code, ConcurrentMap<acceptance_id, hash_value>>
	public static ConcurrentMap<String, ConcurrentMap<String, Integer>> acceptListCache = new ConcurrentHashMap<>();
	
	public static ConcurrentMap<String, ConcurrentMap<String, Integer>> paidOrderCache = new ConcurrentHashMap<>();
}
