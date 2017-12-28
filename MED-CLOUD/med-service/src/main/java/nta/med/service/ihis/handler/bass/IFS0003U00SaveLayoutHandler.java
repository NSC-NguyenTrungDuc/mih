package nta.med.service.ihis.handler.bass;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ifs.Ifs0003;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.service.ihis.proto.BassModelProto.IFS0003U00GrdIFS0003Info;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IFS0003U00SaveLayoutHandler extends ScreenHandler<BassServiceProto.IFS0003U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS0003U00SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0003Repository ifs0003Repository;                                                                    

	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			IFS0003U00SaveLayoutRequest request) throws Exception {
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
  	   	List<IFS0003U00GrdIFS0003Info> listItem = request.getInputListList();
  	   	if(CollectionUtils.isEmpty(request.getInputListList())){
  	   		response.setResult(false);
		}else{
			boolean save = false;
			String hospitalCode = getHospitalCode(vertx, sessionId);
			for(IFS0003U00GrdIFS0003Info item : request.getInputListList()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					String tDupChk = ifs0003Repository.getIfs003U03LayDupCheck(hospitalCode, item.getMapGubun(), DateUtil.toDate(item.getMapGubunYmd(), DateUtil.PATTERN_YYMMDD) ,
							item.getOcsCode(), true);
					if(!StringUtils.isEmpty(tDupChk) || !isValidKey(listItem, getHospitalCode(vertx, sessionId))){
						response.setResult(false);
						response.setMsg(item.getMapGubun() + " "+ item.getMapGubunYmd().toString());
						throw new ExecutionException(response.build());
					}else{
						updateIfs0003Added(item, request.getUserId(), hospitalCode); 
						save =	insertIfs0003(item, request.getUserId(), hospitalCode);
			
					}
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					save = updateIfs0003(item, request.getUserId(), hospitalCode);
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					save = deleteIfs0003(item, hospitalCode);
				}
				
				if(save){
					response.setResult(true);
				}else{
					response.setResult(false);
					throw new ExecutionException(response.build());
				}
			}
		}
				
  		return response.build();																																		
	}    
	
	private boolean insertIfs0003(IFS0003U00GrdIFS0003Info item, String userId, String hospitalCode){
		Ifs0003 ifs0003 = new Ifs0003();
		ifs0003.setSysDate(new Date());
		ifs0003.setSysId(userId);
		ifs0003.setUpdDate(new Date());
		ifs0003.setUpdId(null);
		ifs0003.setHospCode(hospitalCode);
		ifs0003.setMapGubun(item.getMapGubun());
		ifs0003.setMapGubunYmd(DateUtil.toDate(item.getMapGubunYmd(), DateUtil.PATTERN_YYMMDD));
		ifs0003.setOcsCode(item.getOcsCode());
		ifs0003.setOcsDefaultYn(item.getOcsDefaultYn());
		ifs0003.setIfCode(item.getIfCode());
		ifs0003.setIfDefaultYn(item.getIfDefaultYn());
		ifs0003.setRemark(item.getRemark());
		ifs0003.setAcctType(item.getAcctType());
		ifs0003Repository.save(ifs0003);
		return true;
	}
	
	private boolean updateIfs0003Added(IFS0003U00GrdIFS0003Info item, String userId, String hospitalCode){
		if(ifs0003Repository.updateIfs003U00TransactionalAdded(userId, new Date(), item.getRemark(), item.getAcctType(),hospitalCode, item.getMapGubun(),
				DateUtil.toDate(item.getMapGubunYmd(), DateUtil.PATTERN_YYMMDD), item.getOcsCode())>0){
			return true;
		}else{
			return false;
		}
	}
	
	private boolean updateIfs0003(IFS0003U00GrdIFS0003Info item, String userId, String hospitalCode){
		if(ifs0003Repository.updateIFS0003U00Modified(userId, new Date(), DateUtil.toDate(item.getMapGubunYmd(), DateUtil.PATTERN_YYMMDD),
				item.getOcsCode(), item.getOcsDefaultYn(), item.getIfCode(), item.getIfDefaultYn(), item.getRemark(), item.getAcctType(), hospitalCode, item.getMapGubun())>0){
			return true;
		}else{
			return false;
		}
	}
	
	private boolean deleteIfs0003(IFS0003U00GrdIFS0003Info item, String hospitalCode){
		if(ifs0003Repository.deleteIFS003U03Deleted(hospitalCode, item.getMapGubun(), DateUtil.toDate(item.getMapGubunYmd(), DateUtil.PATTERN_YYMMDD),
				item.getOcsCode(), item.getIfCode())>0){
			return true;
		}else{
			return false;
		}
	}

	public boolean isValidKey(List<IFS0003U00GrdIFS0003Info> listItem, String hospCode){
    	for (IFS0003U00GrdIFS0003Info info : listItem) {
            if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
                boolean existed = ifs0003Repository.isExistedIfs0003(hospCode, info.getMapGubun(), info.getOcsCode(), info.getIfCode());
                if(existed){
                	LOGGER.info("IFS0003U00SaveLayoutRequest: IFS0003_DUPLICATE_KEY: hospCode=" + hospCode + ", mapGobun=" + info.getMapGubun() + ", ocsCode=" + info.getOcsCode()
                	+ ", ifCode=" + info.getIfCode());
                	return false;
                }
            } 
    	}
    	
    	return true;
    }		
}