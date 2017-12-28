/**
 * 
 */
package nta.med.service.ihis.handler.clis;

import java.math.BigDecimal;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.clis.ClisPatientStatus;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.clis.ClisPatientStatusRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U04UpdateStatusPatientItemRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.service.ihis.proto.ClisModelProto.CLIS2015U04GetPatientStatusListItemInfo;

@Transactional
@Service
@Scope("prototype")
public class CLIS2015U04UpdateStatusPatientItemHandler extends
		ScreenHandler<ClisServiceProto.CLIS2015U04UpdateStatusPatientItemRequest, UpdateResponse> {
	@Resource
	private ClisPatientStatusRepository clisPatientStatusRepository;

	@Override
	@Route(global = true)
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CLIS2015U04UpdateStatusPatientItemRequest request) throws Exception {
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		boolean save = false;

		if(!CollectionUtils.isEmpty(request.getPatientStatusList())){
			String userId = getUserId(vertx, sessionId);
			for(CLIS2015U04GetPatientStatusListItemInfo item : request.getPatientStatusList()){
				if(item.getRowState().equals(DataRowState.MODIFIED.getValue())){
					if(!StringUtils.isEmpty(item.getPatientStatusId())){
						save = clisPatientStatusRepository.updateCLIS2015U04UpdateStatusPatientItem(
								DateUtil.toDate(item.getUpdateDate(), DateUtil.PATTERN_YYMMDD), userId, Integer.parseInt(item.getPatientStatusId())) > 0;
					} else {
						save = insertCLIS2015U04(item, userId);
					}
				}
			}
		}
		response.setResult(save);
		return response.build();
	}
	
	private boolean insertCLIS2015U04(CLIS2015U04GetPatientStatusListItemInfo item, String userId){
		ClisPatientStatus clisPatientStatus = new ClisPatientStatus();
		clisPatientStatus.setProtocolPatientId(Integer.parseInt(item.getProtocolPatientId()));
		clisPatientStatus.setCode(item.getCode());
		clisPatientStatus.setDescription(item.getDescription());
		clisPatientStatus.setUpdateDate(DateUtil.toDate(item.getUpdateDate(), DateUtil.PATTERN_YYMMDD));
		clisPatientStatus.setSysId(userId);
		clisPatientStatus.setUpdId(userId);
		clisPatientStatus.setActiveFlg(new BigDecimal(1));
		clisPatientStatusRepository.save(clisPatientStatus);
		return true;
	}
}