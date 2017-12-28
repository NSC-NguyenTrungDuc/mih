package nta.med.service.ihis.handler.bass;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ifs.Ifs0003;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto.IFS003U03GridIfs003ListItemInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS003U03TransactionalRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IFS003U03TransactionalHandler extends ScreenHandler<BassServiceProto.IFS003U03TransactionalRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS003U03TransactionalHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0003Repository ifs0003Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			IFS003U03TransactionalRequest request) throws Exception {
      	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
			if(CollectionUtils.isEmpty(request.getListInfoList())){
				response.setResult(false);
			}else{
				String hospitalCode = getHospitalCode(vertx, sessionId);
				for(IFS003U03GridIfs003ListItemInfo item : request.getListInfoList()){
					if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
						String dupChk = ifs0003Repository.getIfs003U03LayDupCheck(hospitalCode, item.getMapGubun(), DateUtil.toDate(item.getMapGubunYmd(), DateUtil.PATTERN_YYMMDD),
								item.getOcsCode(), true);
						if(StringUtils.isEmpty(dupChk)){
							response.setResult(false);
							throw new ExecutionException(response.build());
						}
						
						if(ifs0003Repository.updateIfs003U03TransactionalAdded(request.getUserId(), new Date(), item.getRemark(), hospitalCode, item.getMapGubun(),
								DateUtil.toDate(item.getMapGubunYmd(), DateUtil.PATTERN_YYMMDD), item.getOcsCode())>0){
							response.setResult(true);
						}else{
							response.setResult(false);
							throw new ExecutionException(response.build());
						}
						response.setResult(insertIfs0003(item, request.getUserId(),hospitalCode));
					}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
						if(ifs0003Repository.updateIFS0003U03Modified(request.getUserId(), new Date(), DateUtil.toDate(item.getMapGubunYmd(), DateUtil.PATTERN_YYMMDD),
								item.getOcsCode(), item.getOcsDefaultYn(), item.getIfCode(), item.getIfDefaultYn(), item.getRemark(), hospitalCode, item.getMapGubun())>0){
							response.setResult(true);
						}else{
							response.setResult(false);
							throw new ExecutionException(response.build());
						}
					}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
						if(ifs0003Repository.deleteIFS003U03Deleted(hospitalCode, item.getMapGubun(), DateUtil.toDate(item.getMapGubunYmd(), DateUtil.PATTERN_YYMMDD),
								item.getOcsCode(), item.getIfCode())>0){
							response.setResult(true);
						}else{
							response.setResult(false);
							throw new ExecutionException(response.build());
						}
					}
				}
			}
			return response.build();
	}  
	
	public boolean insertIfs0003(IFS003U03GridIfs003ListItemInfo item, String userId, String hospitalCode){
		Ifs0003 ifs0003 =  new Ifs0003();
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
		ifs0003Repository.save(ifs0003);
		return true;
	}

}