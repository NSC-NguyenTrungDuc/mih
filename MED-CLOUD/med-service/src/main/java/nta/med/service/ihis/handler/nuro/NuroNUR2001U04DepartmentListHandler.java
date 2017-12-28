package nta.med.service.ihis.handler.nuro;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroNUR2001U04DepartmentListHandler extends ScreenHandler<NuroServiceProto.NuroNUR2001U04DepartmentListRequest, NuroServiceProto.NuroNUR2001U04DepartmentListResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroNUR2001U04DepartmentListHandler.class);
	@Resource
	private Bas0260Repository bas0260Repository;

    @Override
	public boolean isValid(NuroServiceProto.NuroNUR2001U04DepartmentListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getComingDate()) && DateUtil.toDate(request.getComingDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroNUR2001U04DepartmentListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroNUR2001U04DepartmentListRequest request) throws Exception {
		 NuroServiceProto.NuroNUR2001U04DepartmentListResponse.Builder response = NuroServiceProto.NuroNUR2001U04DepartmentListResponse.newBuilder();
		 Date comingDate = DateUtil.toDate(request.getComingDate(), DateUtil.PATTERN_YYMMDD);
         List<ComboListItemInfo> listObject = bas0260Repository.getComboDepartmentItemInfo(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), comingDate, true);
         if (listObject != null && !listObject.isEmpty()) {
             for (ComboListItemInfo obj : listObject) {
             	CommonModelProto.ComboListItemInfo.Builder comboInfo = CommonModelProto.ComboListItemInfo.newBuilder();
                 comboInfo.setCode(obj.getCode());
                 comboInfo.setCodeName(obj.getCodeName());
                 response.addDeptListItem(comboInfo);
             }
         }
		return response.build();
	}
}
