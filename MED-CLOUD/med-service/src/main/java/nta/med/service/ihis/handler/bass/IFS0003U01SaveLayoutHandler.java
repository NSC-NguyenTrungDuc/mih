package nta.med.service.ihis.handler.bass;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ifs.Ifs0003;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto.IFS0003U01GrdIFS0003Info;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U01SaveLayoutRequest;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U01SaveLayoutResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class IFS0003U01SaveLayoutHandler extends ScreenHandler<BassServiceProto.IFS0003U01SaveLayoutRequest, BassServiceProto.IFS0003U01SaveLayoutResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS0003U01SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0003Repository ifs0003Repository;   
	
	@Override                                                                                                       
	public IFS0003U01SaveLayoutResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			IFS0003U01SaveLayoutRequest request) throws Exception {
  	   	BassServiceProto.IFS0003U01SaveLayoutResponse.Builder response = BassServiceProto.IFS0003U01SaveLayoutResponse.newBuilder();                      
		Integer result = null;
		String hospitalCode = getHospitalCode(vertx, sessionId);
  	   	if(!CollectionUtils.isEmpty(request.getGrdIfsItemList())) {
  	   		for(IFS0003U01GrdIFS0003Info info : request.getGrdIfsItemList()){
  	   			if (!StringUtils.isEmpty(info.getMapGubunYmd()) && DateUtil.toDate(info.getMapGubunYmd(), DateUtil.PATTERN_YYMMDD) == null) {
					throw new ExecutionException(response.build());
  	   			}else{
  	   				Date mapGubunYmd = DateUtil.toDate(info.getMapGubunYmd(), DateUtil.PATTERN_YYMMDD);
  	   				if(DataRowState.ADDED.getValue().equals(info.getRowState())){
  	   					String getY = ifs0003Repository.getIfs003U03LayDupCheck(hospitalCode, info.getMapGubun(), mapGubunYmd, info.getOcsCode(), true);
  	   					if("Y".equalsIgnoreCase(getY)){
  	   					    String mapGubun = info.getMapGubun();
  	   					    String sMapGubunYmd = info.getMapGubunYmd();
  	   					    if(!StringUtils.isEmpty(mapGubun)){
  	   					    	response.setMapGubun(mapGubun);
  	   					    }
  	   					    if(!StringUtils.isEmpty(sMapGubunYmd)){
  	   					    	response.setMapGubunYmd(sMapGubunYmd);
  	   					    }
							throw new ExecutionException(response.build());
  	   					}
  	   					result = ifs0003Repository.updateIfs003U03TransactionalAdded(request.getUserId(), new Date(), 
  	   							info.getRemark(), hospitalCode, info.getMapGubun(), mapGubunYmd, info.getOcsCode());
  	   					
  	   					String getYByMapGubunOcsCodeAndIfCode = ifs0003Repository.getYByMapGubunOcsCodeAndIfCode(hospitalCode, info.getMapGubun(),
  	   							info.getOcsCode(), info.getIfCode());
  	   					if("Y".equalsIgnoreCase(getYByMapGubunOcsCodeAndIfCode)){
  	   						result = ifs0003Repository.updateIFS0003ByMapGubunOcsCodeAndIfCode(hospitalCode, mapGubunYmd,
  	   								info.getOcsDefaultYn(), info.getIfDefaultYn(), info.getRemark(), info.getMapGubun(), info.getOcsCode(), info.getIfCode());
  	   					}else{
  	   						insertIfs0003(info, request.getUserId(), hospitalCode);
  	   						result = 1;
  	   					}
  	   				}else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())){ 
  	   					result = ifs0003Repository.updateIFS0003U03Modified(request.getUserId(), new Date(), mapGubunYmd, 
  	   						 info.getOcsCode(), info.getOcsDefaultYn(), info.getIfCode(), info.getIfDefaultYn(), info.getRemark(), hospitalCode, info.getMapGubun());
  	   				}else if(DataRowState.DELETED.getValue().equals(info.getRowState())){
  	   					result = ifs0003Repository.deleteIFS003U03Deleted(hospitalCode, info.getMapGubun(), mapGubunYmd, info.getOcsCode(), info.getIfCode());
  	   				}
  	   			}
  	   		}
  	   	}
  	   	return response.build();
	}   
	private void insertIfs0003(IFS0003U01GrdIFS0003Info info, String userId, String hospitalCode){
		Ifs0003 ifs0003 = new Ifs0003();
		Date mapGubunYmd = DateUtil.toDate(info.getMapGubunYmd(), DateUtil.PATTERN_YYMMDD);
		ifs0003.setSysDate(new Date());
		ifs0003.setSysId(userId);
		ifs0003.setUpdDate(new Date());
		ifs0003.setUpdId(userId);
		ifs0003.setHospCode(hospitalCode);
		ifs0003.setMapGubun(StringUtils.isEmpty(info.getMapGubun()) ? null : info.getMapGubun());
		ifs0003.setMapGubunYmd(mapGubunYmd);
		ifs0003.setOcsCode(StringUtils.isEmpty(info.getOcsCode()) ? null : info.getOcsCode());
		ifs0003.setOcsDefaultYn(info.getOcsDefaultYn());
		ifs0003.setIfCode(StringUtils.isEmpty(info.getIfCode()) ? null : info.getIfCode());
		ifs0003.setIfDefaultYn(info.getIfDefaultYn());
		ifs0003Repository.save(ifs0003);
	}
}