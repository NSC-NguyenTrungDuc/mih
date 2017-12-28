package nta.med.service.ihis.handler.nuri;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur0101Repository;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.NuriModelProto.NUR0101U00grdDetailInfo;
import nta.med.service.ihis.proto.NuriModelProto.NUR0101U00grdMasterInfo;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;
import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.nur.Nur0101;
import nta.med.core.domain.nur.Nur0102;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang3.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class NUR0101U00SaveLayoutHandler extends ScreenHandler<NuriServiceProto.NUR0101U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {   
	
	@Resource                                   
	private Nur0101Repository nur0101Repository;
	
	@Resource                                                                                                       
	private Nur0102Repository nur0102Repository;

	@Override
	@Route(global = true)
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR0101U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder(); 
		String userId = getUserId(vertx, sessionId);
		response = saveLayout(request, getLanguage(vertx, sessionId), userId);
		if(!response.getResult()){
			throw new ExecutionException(response.build());
		}
		return response.build();
	}

	@Override
	@Route(global = false)
	public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR0101U00SaveLayoutRequest request, UpdateResponse rs) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = rs.toBuilder();
		List<NUR0101U00grdDetailInfo> listSystemItem = request.getGrddetailinfoList();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		
		if(!CollectionUtils.isEmpty(listSystemItem)){
			for(NUR0101U00grdDetailInfo item : listSystemItem){
				if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					Nur0102 nur0102 = new Nur0102();
					nur0102.setSysDate(new Date());
					nur0102.setSysId(userId);
					nur0102.setUpdDate(new Date());
					nur0102.setUpdId(userId);
					nur0102.setHospCode(hospCode);
					nur0102.setLanguage(language);
					nur0102.setCodeType(item.getCodeType());
					nur0102.setCode(item.getCode());
					nur0102.setCodeName(item.getCodeName());
					if(item.getStartDate() != "" || !StringUtils.isEmpty(item.getStartDate())){
						nur0102.setStartDate(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
					}
					if(item.getEndDate() != "" || !StringUtils.isEmpty(item.getEndDate())){
						nur0102.setEndDate(DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD));
					}
					nur0102.setSortKey(CommonUtils.parseDouble(item.getSortKey()));
					nur0102.setGroupKey(item.getGroupKey());
					nur0102.setMent(item.getMent());
					
					nur0102Repository.save(nur0102);
				} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					Date startDate = null;
					Date endDate = null;
					if(item.getStartDate() != "" || !StringUtils.isEmpty(item.getStartDate())){
						startDate = DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD);
					}
					if(item.getEndDate() != "" || !StringUtils.isEmpty(item.getEndDate())){
						startDate = DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD);
					}
					
					if(nur0102Repository.updateNUR0101U00WhereHospCodeCodeTypeCode(userId, new Date(), item.getCodeType(), item.getCode(),
							item.getCodeName(), CommonUtils.parseDouble(item.getSortKey()), item.getGroupKey(), startDate, endDate, item.getMent(), hospCode, language) <= 0 ){
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
				} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if(nur0102Repository.deleteNUR0101U00Case2Deleted(hospCode, language, item.getCodeType(), item.getCode()) <= 0 ){
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
				}
			}
		}
		
		response.setResult(true);
		return response.build();
	}
	
	public SystemServiceProto.UpdateResponse.Builder saveLayout(NuriServiceProto.NUR0101U00SaveLayoutRequest request, String language, String userId){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<NUR0101U00grdMasterInfo> listGroupItem = request.getGrdmasterinfoList();
		if(!CollectionUtils.isEmpty(listGroupItem)){
			for(NUR0101U00grdMasterInfo item : listGroupItem){
				if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					Nur0101 nur0101 = new Nur0101();
					nur0101.setSysDate(new Date());
					nur0101.setSysId(userId);
					nur0101.setUpdDate(new Date());
					nur0101.setUpdId(userId);
					nur0101.setCodeType(item.getCodeType());
					nur0101.setCodeTypeName(item.getCodeTypeName());
					//nur0101.setAdminGubun(item.getAdminGubun());
					nur0101.setLanguage(language);
					nur0101Repository.save(nur0101);
				} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if(nur0101Repository.updateNUR0101U00Case1Modified(userId, new Date(), item.getCodeType(), item.getCodeTypeName(), language) <= 0){
						response.setResult(false);
						return response;
					}
				} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if(nur0101Repository.deleteNUR0101U00Case2Deleted(item.getCodeType(), language) <= 0 ){
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
