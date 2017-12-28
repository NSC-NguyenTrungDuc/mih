package nta.med.service.ihis.handler.bass;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0101;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0101Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto.BAS0101U00GrdMasterItemInfo;
import nta.med.service.ihis.proto.BassModelProto.BAS0101U00grdDetailItemInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0101U00ExecuteRequest;
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

@Service
@Scope("prototype")
@Transactional
public class BAS0101U00ExecuteHandler extends ScreenHandler<BassServiceProto.BAS0101U00ExecuteRequest, SystemServiceProto.UpdateResponse>{
	private static final Log LOGGER = LogFactory.getLog(BAS0101U00ExecuteHandler.class);
	@Resource
	private Bas0102Repository bas0102Repository;
	@Resource
	private Bas0101Repository bas0101Repository;
	
	@Override
	@Route(global = false)
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0101U00ExecuteRequest request)
			throws Exception {
			 SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
			 String hospitalCode = getHospitalCode(vertx, sessionId);
			 String language = getLanguage(vertx, sessionId);
			 if(CollectionUtils.isEmpty(request.getMasterInputListList()) 
					 && CollectionUtils.isEmpty(request.getDetailInputListList())){
				 response.setResult(false);
			 }else{
				 if(!CollectionUtils.isEmpty(request.getMasterInputListList())){
					 for(BAS0101U00GrdMasterItemInfo item : request.getMasterInputListList()){
						  if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
							 String tChk = bas0102Repository.checkExitsByCodeType(hospitalCode, item.getCodeType(), language); 
							 if(!StringUtils.isEmpty(tChk)){
								 response.setResult(false);
								 throw new ExecutionException(response.build());
							 }
						 }
					 }
				 }
				 if(!CollectionUtils.isEmpty(request.getDetailInputListList())){
					 for(BAS0101U00grdDetailItemInfo item : request.getDetailInputListList()){
						 if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
							 String tChk = bas0102Repository.getTChkBAS0101U00Execute(hospitalCode, item.getCodeType(),
									 item.getCode(), language);
							 if(!StringUtils.isEmpty(tChk)){
								 response.setResult(false);
								 response.setMsg(item.getCode());
								 throw new ExecutionException(response.build());
							 }
							 insert0102Bas0101(item, request.getUserId(), hospitalCode, language);
						 }else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
							 if(bas0102Repository.updateBAS0101U00Execute(hospitalCode, request.getUserId(), new Date(),
									 item.getCodeName(), item.getGroupKey(), item.getRemark(), CommonUtils.parseDouble(item.getSortKey()) , item.getCodeType(),
									 item.getCode(), language)<=0){
								 response.setResult(false);
								 throw new ExecutionException(response.build());
							 }
						 }else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
							 if(bas0102Repository.deleteBAS0101U00Execute(hospitalCode, item.getCodeType(), item.getCode(),
									 language)<=0){
								 response.setResult(false);
								 throw new ExecutionException(response.build());
							 }
						 }
					 }

				 }
				 response.setResult(true);
			 }
        return response.build();
	}
	@Override
	@Route(global = true)
	public UpdateResponse postHandle(Vertx vertx, String clientId,
								 String sessionId, long contextId, BAS0101U00ExecuteRequest request, SystemServiceProto.UpdateResponse response)
	{
		SystemServiceProto.UpdateResponse.Builder updateResponse = response.toBuilder();
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		if(CollectionUtils.isEmpty(request.getMasterInputListList())
				&& CollectionUtils.isEmpty(request.getDetailInputListList())){
			updateResponse.setResult(false);
		}else {
			if (!CollectionUtils.isEmpty(request.getMasterInputListList())) {
				for (BAS0101U00GrdMasterItemInfo item : request.getMasterInputListList()) {
					if (item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
						String tChk = bas0101Repository.checkExitsByCodeType(item.getCodeType(), language);
						if (!StringUtils.isEmpty(tChk)) {
							updateResponse.setResult(false);
							updateResponse.setMsg(item.getCodeType());
							throw new ExecutionException(updateResponse.build());
						}
						insertBas0101(item, request.getUserId(), hospitalCode, language);
					} else if (item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
						if (bas0101Repository.updateBas0101U00TransactionModified(request.getUserId(), new Date(), item.getCodeTypeName(), item.getCodeType(), language) <= 0) {
							updateResponse.setResult(false);
							throw new ExecutionException(updateResponse.build());
						}
					} else if (item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
//						String tChk = bas0102Repository.checkExitsByCodeType(hospitalCode, item.getCodeType(), language);
//						if (!StringUtils.isEmpty(tChk)) {
//							updateResponse.setResult(false);
//							throw new ExecutionException(updateResponse.build());
//						}
						if (bas0101Repository.deleteBas0101U00TransactionDeleted(item.getCodeType(), language) <= 0) {
							updateResponse.setResult(false);
							throw new ExecutionException(updateResponse.build());
						}
					}
				}
			}
			updateResponse.setResult(true);
		}
		return updateResponse.build();
	}
	private void insert0102Bas0101(BAS0101U00grdDetailItemInfo item , String userId, String hospitalCode, String language){
		Bas0102 bas0102 = new Bas0102();
		bas0102.setSysDate(new Date());
		bas0102.setSysId(userId);
		bas0102.setUpdDate(new Date());
		bas0102.setUpdId(userId);
		bas0102.setHospCode(hospitalCode);
		bas0102.setCodeType(item.getCodeType());
		bas0102.setCode(item.getCode());
		bas0102.setCodeName(item.getCodeName());
		bas0102.setGroupKey(item.getGroupKey());
		bas0102.setRemark(item.getRemark());
		bas0102.setSortKey(CommonUtils.parseDouble(item.getSortKey()));
		bas0102.setLanguage(language);
		bas0102Repository.save(bas0102);
	}
	
	private void insertBas0101(BAS0101U00GrdMasterItemInfo item, String userId, String hospitalCode, String language){
		Bas0101 bas0101 = new Bas0101();
		bas0101.setSysDate(new Date());
		bas0101.setSysId(userId);
		bas0101.setUpdDate(new Date());
		bas0101.setUpdId(userId);
		bas0101.setCodeType(item.getCodeType());
		bas0101.setCodeTypeName(item.getCodeTypeName());
		bas0101.setLanguage(language);
		bas0101Repository.save(bas0101);
	}
}
