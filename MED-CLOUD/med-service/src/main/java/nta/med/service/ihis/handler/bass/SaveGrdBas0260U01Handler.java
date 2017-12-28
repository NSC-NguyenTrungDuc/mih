package nta.med.service.ihis.handler.bass;

import java.sql.Timestamp;
import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.hibernate.exception.ConstraintViolationException;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0260S;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0260SRepository;
import nta.med.service.ihis.proto.BassModelProto.LoadGrdBAS0260U01Info;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.SaveGrdBas0260U01Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class SaveGrdBas0260U01Handler extends ScreenHandler<BassServiceProto.SaveGrdBas0260U01Request, SystemServiceProto.UpdateResponse> {                             
	
	private static final Log LOGGER = LogFactory.getLog(SaveGrdBas0260U01Handler.class);                                        
	
	@Resource                                                                                                       
	private Bas0260SRepository bas0260SRepository;                                                                    
	
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SaveGrdBas0260U01Request request) throws Exception {                 
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		if (!CollectionUtils.isEmpty(request.getListInfoList())) {
			for (LoadGrdBAS0260U01Info item : request.getListInfoList()) {
				Boolean isDuplicateKey = bas0260SRepository.isExistedBAS0260S(item.getBuseoCode(), item.getGwa(), getLanguage(vertx, sessionId));
				if (item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
					if (isDuplicateKey) {
						response.setResult(false);
						response.setMsg("duplicate");
					} else {
						response.setResult(insertBas0260U01(item, getUserId(vertx, sessionId)));
					}
				} else if (item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
					Bas0260S bas0260s = bas0260SRepository.findOne(Long.valueOf(item.getId()));
					if ((!item.getGwa().equals(bas0260s.getGwa()) || !item.getBuseoCode().equals(bas0260s.getBuseoCode())) && isDuplicateKey) {
						response.setResult(false);
						response.setMsg("duplicate");
					} else {
						boolean result = updateBas0260U01(item, getUserId(vertx, sessionId));
						if (!result) {
							response.setResult(false);
							throw new ExecutionException(response.build());
						} else {
							response.setResult(true);
						}
					}
					
				} else if (item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
					if (!deleteBas0260U01(item)) {
						response.setResult(false);
						throw new ExecutionException(response.build());
					} else {
						response.setResult(true);
					}
				}
			}
		}
		return response.build();
	}															
	
	public boolean insertBas0260U01(LoadGrdBAS0260U01Info item, String userId){
		Bas0260S bas0260s = new Bas0260S();
		Date sysDate = new Date();
		if(!StringUtils.isEmpty(userId)){
			bas0260s.setUpdId(userId);
			bas0260s.setSysId(userId);
		}
		bas0260s.setBuseoCode(item.getBuseoCode());
		bas0260s.setBuseoName(item.getBuseoName());
		bas0260s.setBuseoName2(item.getBuseoName2());
		bas0260s.setBuseoGubun(item.getBuseoGubun());
		bas0260s.setParentBuseo(StringUtils.isEmpty(item.getParentBuseo()) ? null : item.getParentBuseo());
		bas0260s.setGwa(StringUtils.isEmpty(item.getGwa()) ? null : item.getGwa());
		bas0260s.setGwaName(StringUtils.isEmpty(item.getGwaName()) ? null : item.getGwaName());
		bas0260s.setGwaName2(StringUtils.isEmpty(item.getGwaName2()) ? null : item.getGwaName2());
		bas0260s.setParentGwa(StringUtils.isEmpty(item.getParentGwa()) ? null : item.getParentGwa());	
		bas0260s.setNote(StringUtils.isEmpty(item.getNote()) ? null : item.getNote());
		bas0260s.setCreated(new Timestamp(sysDate.getTime()));
		bas0260s.setUpdated(new Timestamp(sysDate.getTime()));
		bas0260s.setLanguage(item.getLanguage());
		bas0260s.setActiveFlg(item.getActiveFlg());
		bas0260SRepository.save(bas0260s);
		return true;
	}
	
	public boolean updateBas0260U01(LoadGrdBAS0260U01Info item, String userId){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		try {
			
			Bas0260S bas0260s = bas0260SRepository.findOne(Long.valueOf(item.getId()));
			if(bas0260s == null ) return false;
			bas0260s.setBuseoCode(item.getBuseoCode());
			bas0260s.setBuseoName(item.getBuseoName());
			bas0260s.setBuseoName2(item.getBuseoName2());
			bas0260s.setBuseoGubun(item.getBuseoGubun());
			bas0260s.setParentBuseo(StringUtils.isEmpty(item.getParentBuseo()) ? null : item.getParentBuseo());
			bas0260s.setGwa(StringUtils.isEmpty(item.getGwa()) ? null : item.getGwa());
			bas0260s.setGwaName(StringUtils.isEmpty(item.getGwaName()) ? null : item.getGwaName());
			bas0260s.setGwaName2(StringUtils.isEmpty(item.getGwaName2()) ? null : item.getGwaName2());
			bas0260s.setParentGwa(StringUtils.isEmpty(item.getParentGwa()) ? null : item.getParentGwa());
			bas0260s.setNote(StringUtils.isEmpty(item.getNote()) ? null : item.getNote());
			
			bas0260SRepository.save(bas0260s);
			return bas0260s != null && bas0260s.getId() != null;
			
		} catch (ConstraintViolationException  e) {
			
			response.setResult(false);
			response.setMsg("duplicate");
			LOGGER.info("SaveGrdBas0260U01Handler Exception", e);
			throw new ExecutionException(response.build());
		}
		
	}
	
	public boolean deleteBas0260U01(LoadGrdBAS0260U01Info item){
		Bas0260S bas0260s = bas0260SRepository.findOne(Long.valueOf(item.getId()));
		if(bas0260s == null ) return false;
		bas0260s.setActiveFlg("0");
		bas0260SRepository.save(bas0260s);
		return bas0260s != null && bas0260s.getId() != null;
	}
}