package nta.med.service.ihis.handler.bass;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ifs.Ifs0004;
import nta.med.core.domain.ifs.Ifs0005;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ifs.Ifs0004Repository;
import nta.med.data.dao.medi.ifs.Ifs0005Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto.IFS0004U01grdDetailtListItemInfo;
import nta.med.service.ihis.proto.BassModelProto.IFS0004U01grdMasterListItemInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0004U01TransactionalRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;
@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IFS0004U01TransactionalHandler extends ScreenHandler<BassServiceProto.IFS0004U01TransactionalRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS0004U01TransactionalHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0005Repository ifs0005Repository;        
	@Resource                                                                                                       
	private Ifs0004Repository ifs0004Repository;   
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			IFS0004U01TransactionalRequest request) throws Exception {
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();   
  	   	String hospitalCode = getHospitalCode(vertx, sessionId);
		if(CollectionUtils.isEmpty(request.getListDetailList()) && CollectionUtils.isEmpty(request.getListMasterList())){
			response.setResult(false);
		}else{
			//detail
			for(IFS0004U01grdDetailtListItemInfo item : request.getListDetailList()){
				boolean detail = false;
				if(item.getRowState().equals(DataRowState.ADDED.getValue())){
					detail = insertIfs0005(item, request.getUserId(), hospitalCode);
				}else if(item.getRowState().equals(DataRowState.MODIFIED.getValue())){
					if(ifs0005Repository.updateIFS0004U01Ifs0005(request.getUserId(), new Date(), item.getBunCode(), item.getSgCode(), hospitalCode,
							item.getNuGubun(), item.getNuCode(), DateUtil.toDate(item.getNuYmd(), DateUtil.PATTERN_YYMMDD))>0){
						detail = true;
					}
				}else if(item.getRowState().equals(DataRowState.DELETED.getValue())){
					if(ifs0005Repository.deleteIFS0004U01Ifs0005(hospitalCode, item.getNuGubun(), item.getNuCode(), 
							DateUtil.toDate(item.getNuYmd(), DateUtil.PATTERN_YYMMDD), item.getBunCode(), item.getSgCode()) >0){
						detail = true;
					}
				}
				if(!detail){
					response.setResult(false);
					throw new ExecutionException(response.build());
				}
			}
			// master
			for(IFS0004U01grdMasterListItemInfo item : request.getListMasterList()){
				boolean master = false;
				if(item.getRowState().equals(DataRowState.ADDED.getValue())){
					master = insertIfs0004(item, request.getUserId(), hospitalCode);
				}else if(item.getRowState().equals(DataRowState.MODIFIED.getValue())){
					if(ifs0004Repository.updateIFS0004U01ifs0004(request.getUserId(), new Date(), item.getNuCodeName(), hospitalCode, item.getNuGubun(),
							item.getNuCode(), DateUtil.toDate(item.getNuYmd(), DateUtil.PATTERN_YYMMDD)) >0){
						master = true;
					}
				}else if(item.getRowState().equals(DataRowState.DELETED.getValue())){
					if(ifs0004Repository.deleteIFS0004U01ifs0004(hospitalCode, item.getNuGubun(), item.getNuCode(), DateUtil.toDate(item.getNuYmd(), DateUtil.PATTERN_YYMMDD)) >0){
						master = true;
					}
				}
				if(!master){
					response.setResult(false);
					throw new ExecutionException(response.build());
				}
			}
			response.setResult(true);
		}
		return response.build();
	}   
	
	public boolean insertIfs0005(IFS0004U01grdDetailtListItemInfo item, String userId, String hospitalCode){
		Ifs0005 ifs0005 = new Ifs0005();
		ifs0005.setSysDate(new Date());
		ifs0005.setSysId(userId);
		ifs0005.setUpdDate(null);
		ifs0005.setUpdId(null);
		ifs0005.setHospCode(hospitalCode);
		ifs0005.setNuGubun(item.getNuGubun());
		ifs0005.setNuCode(item.getNuCode());
		ifs0005.setNuYmd(DateUtil.toDate(item.getNuYmd(), DateUtil.PATTERN_YYMMDD));
		ifs0005.setBunCode(item.getBunCode());
		ifs0005.setSgCode(item.getSgCode());
		ifs0005Repository.save(ifs0005);
		return true;
	}
	
	public boolean insertIfs0004(IFS0004U01grdMasterListItemInfo item, String userId, String hospitalCode){
		Ifs0004 ifs0004 = new Ifs0004();
		ifs0004.setSysDate(new Date());
		ifs0004.setSysId(userId);
		ifs0004.setUpdDate(null);
		ifs0004.setUpdId(null);
		ifs0004.setHospCode(hospitalCode);
		ifs0004.setNuGubun(item.getNuGubun());
		ifs0004.setNuCode(item.getNuCode());
		ifs0004.setNuYmd(DateUtil.toDate(item.getNuYmd(), DateUtil.PATTERN_YYMMDD));
		ifs0004.setNuCodeName(item.getNuCodeName());
		ifs0004Repository.save(ifs0004);
		return true;
	}
}