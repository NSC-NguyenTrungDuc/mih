package nta.med.service.ihis.handler.ocsa;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs0131;
import nta.med.core.domain.ocs.Ocs0132;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0131Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.Ocs0131U01Grd0131ListItemInfo;
import nta.med.service.ihis.proto.OcsaModelProto.Ocs0131U01Grd0132ListItemInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.Ocs0131U01SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class Ocs0131U01SaveLayoutHandler
	extends ScreenHandler<OcsaServiceProto.Ocs0131U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(Ocs0131U01SaveLayoutHandler.class);        
	
	@Resource                                                                                                       
	private Ocs0131Repository ocs0131Repository;
	
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;   
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			Ocs0131U01SaveLayoutRequest request) throws Exception {                                                                   
      	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();     
      	   	String hospCode = getHospitalCode(vertx, sessionId);
      	   	String language = getLanguage(vertx, sessionId);
			response = saveLayout(request, hospCode, language);
			if(!response.getResult()){
				throw new ExecutionException(response.build());
			}
			return response.build();
	}
	
	public SystemServiceProto.UpdateResponse.Builder saveLayout(OcsaServiceProto.Ocs0131U01SaveLayoutRequest request, String hospCode, String language){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<Ocs0131U01Grd0131ListItemInfo> listGrd0131 = request.getGrd0131ItemList();
		if(!CollectionUtils.isEmpty(listGrd0131)){
			for(Ocs0131U01Grd0131ListItemInfo item : listGrd0131){
				if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					Ocs0131 ocs0131 = new Ocs0131();
					ocs0131.setSysDate(new Date());
					ocs0131.setSysId(request.getUserId());
					ocs0131.setUpdDate(new Date());
					ocs0131.setCodeType(item.getCodeType());
					ocs0131.setCodeTypeName(item.getCodeTypeName());
					ocs0131.setMent("USER");
					ocs0131.setChoiceUser(item.getChoiceUser());
					ocs0131.setLanguage(language);
					ocs0131Repository.save(ocs0131);
				} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if(ocs0131Repository.updateXSavePerformer(request.getUserId(), new Date(), item.getCodeTypeName(), item.getMent(), item.getChoiceUser(), item.getCodeType(), language) <= 0){
						response.setResult(false);
						return response;
					}
				} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if(ocs0131Repository.deleteXSavePerformer(item.getCodeType(), language) <= 0 ){
						response.setResult(false);
						return response;
					}
				}
			}
		}
		
		List<Ocs0131U01Grd0132ListItemInfo> listGrd0132 = request.getGrd0132ItemList();
		if(!CollectionUtils.isEmpty(listGrd0132)){
			for(Ocs0131U01Grd0132ListItemInfo item : listGrd0132){
				if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					Ocs0132 ocs0132 = new Ocs0132();
					ocs0132.setSysDate(new Date());
					ocs0132.setSysId(request.getUserId());
					ocs0132.setUpdDate(new Date());
					ocs0132.setCodeType(item.getCodeType());
					ocs0132.setCode(item.getCode());
					ocs0132.setCodeName(item.getCodeName());
					if(StringUtils.isEmpty(item.getSortKey())){
						ocs0132.setSortKey(0D);
					} else {
						ocs0132.setSortKey(CommonUtils.parseDouble(item.getSortKey()));
					}
					ocs0132.setGroupKey(item.getGroupKey());
					ocs0132.setMent(item.getMent());
					if(StringUtils.isEmpty(item.getValuePoint())){
						ocs0132.setValuePoint(0D);
					} else {
						ocs0132.setValuePoint(CommonUtils.parseDouble(item.getValuePoint()));
					}
					ocs0132.setHospCode(hospCode);
					ocs0132.setLanguage(language);
					ocs0132Repository.save(ocs0132);
				} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if(ocs0132Repository.updateXSavePerformer(request.getUserId(), new Date(), item.getCodeName(), CommonUtils.parseDouble(item.getSortKey()), item.getGroupKey(), 
							item.getMent(), CommonUtils.parseDouble(item.getValuePoint()), item.getCodeType(), item.getCode(), hospCode) <= 0 ){
						response.setResult(false);
						return response;
					}
				} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if(ocs0132Repository.deleteXSavePerformer(item.getCodeType(), item.getCode(), hospCode) <= 0 ){
						response.setResult(false);
						return response;
					}
				}
			}
		}
		
		response.setResult(true);
		return response;
	}

}
