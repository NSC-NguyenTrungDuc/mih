package nta.med.service.ihis.handler.bass;

import java.util.Date;

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
import nta.med.core.domain.ifs.Ifs0001;
import nta.med.core.domain.ifs.Ifs0002;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.ifs.Ifs0001Repository;
import nta.med.data.dao.medi.ifs.Ifs0002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto.IFS0001U00GrdDetailInfo;
import nta.med.service.ihis.proto.BassModelProto.IFS0001U00GrdMasterInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0001U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype")       
@Transactional
public class IFS0001U00SaveLayoutHandler extends ScreenHandler<BassServiceProto.IFS0001U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS0001U00SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0001Repository ifs0001Repository;                                                                    
	@Resource
	private Ifs0002Repository ifs0002Repository;
	
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			IFS0001U00SaveLayoutRequest request) throws Exception {
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();       
  	   	response.setResult(true);
  	   	Integer result = null;
  	   	String msg = null;
  	   	String hospitalCode = getHospitalCode(vertx, sessionId);
		//callerId = 1
  	   	if(!CollectionUtils.isEmpty(request.getGrdMstItemList())) {
			for(IFS0001U00GrdMasterInfo info : request.getGrdMstItemList()){
				if(DataRowState.ADDED.getValue().equals(info.getRowState())){
					String getY = ifs0001Repository.checkExitsByCodeType(hospitalCode, info.getCodeType());
					if("Y".equalsIgnoreCase(getY)){
						msg = "1-" + info.getCodeType();
						response.setMsg(msg);
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
					insertIfs0001(info, request.getUserId(), hospitalCode);
					result = 1;
				}else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())){
					result = ifs0001Repository.getUpdateIFS0001U00SaveLayout(request.getUserId(), new Date(), info.getCodeTypeName(), info.getRemark(),
							hospitalCode, info.getCodeType(), info.getAcctType());
				}else if(DataRowState.DELETED.getValue().equals(info.getRowState())){
					String getY = ifs0002Repository.checkExitsByCodeType(hospitalCode, info.getCodeType());
					if("Y".equalsIgnoreCase(getY)){
						msg = "2-" + info.getCodeType();
						response.setMsg(msg);
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
					 result = ifs0001Repository.getDeleteIFS0001U00SaveLayout(hospitalCode, info.getCodeType());
				}
			}
  	   	}
  	   	if(!CollectionUtils.isEmpty(request.getGrdDetailItemList())) {
			//callerId = 2
			for(IFS0001U00GrdDetailInfo info : request.getGrdDetailItemList()){
				if(DataRowState.ADDED.getValue().equals(info.getRowState())){
					String getY = ifs0002Repository.checkExitsByCodeAndCodeType(hospitalCode, info.getCodeType(), info.getCode());
					if("Y".equalsIgnoreCase(getY)){
						msg = "3-" + info.getCode();
						response.setMsg(msg);
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
					insertIfs0002(info, request.getUserId(), hospitalCode);
					result = 1;
				}else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())){
					result = ifs0002Repository.getUpdateIFS0001U00SaveLayout(request.getUserId(), new Date(), info.getCodeName(), info.getRemark(),
						hospitalCode, info.getCodeType(), info.getCode(), info.getAcctType());
				}else if(DataRowState.DELETED.getValue().equals(info.getRowState())){
					result = ifs0002Repository.getDeleteIFS0001U00SaveLayout(hospitalCode, info.getCodeType(), info.getCode());
				}
			}
  	   	}

		if(StringUtils.isEmpty(result)){
			response.setResult(false);
		}else{
			response.setResult(true);
		}
		return response.build();
	} 
	
	private void insertIfs0001(IFS0001U00GrdMasterInfo info, String userId, String hospitalCode){
		Ifs0001 ifs0001 = new Ifs0001();
		ifs0001.setSysDate(new Date());
		ifs0001.setSysId(userId);
		ifs0001.setUpdDate(new Date());
		ifs0001.setUpdId(userId);
		ifs0001.setHospCode(hospitalCode);
		ifs0001.setCodeType(StringUtils.isEmpty(info.getCodeType()) ? null : info.getCodeType());
		ifs0001.setCodeTypeName(info.getCodeTypeName());
		ifs0001.setRemark(info.getRemark());
		ifs0001.setAcctType(info.getAcctType());
		ifs0001Repository.save(ifs0001);
	}
	private void insertIfs0002(IFS0001U00GrdDetailInfo info, String userId, String hospitalCode){
		Ifs0002 ifs0002 = new Ifs0002();
		ifs0002.setSysDate(new Date());
		ifs0002.setSysId(userId);
		ifs0002.setUpdDate(new Date());
		ifs0002.setUpdId(userId);
		ifs0002.setHospCode(hospitalCode);
		ifs0002.setCodeType(StringUtils.isEmpty(info.getCodeType()) ? null : info.getCodeType());
		ifs0002.setCode(StringUtils.isEmpty(info.getCode()) ? null : info.getCode());
		ifs0002.setCodeName(info.getCodeName());
		ifs0002.setRemark(info.getRemark());
		ifs0002.setAcctType(info.getAcctType());
		ifs0002Repository.save(ifs0002);
	}
}