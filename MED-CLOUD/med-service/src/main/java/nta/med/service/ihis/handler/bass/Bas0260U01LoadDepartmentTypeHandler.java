package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.bass.LoadDepartmentTypeInfo;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.Bas0260U01LoadDepartmentTypeRequest;
import nta.med.service.ihis.proto.BassServiceProto.Bas0260U01LoadDepartmentTypeResponse;

@Service
@Scope("prototype")
public class Bas0260U01LoadDepartmentTypeHandler extends
		ScreenHandler<BassServiceProto.Bas0260U01LoadDepartmentTypeRequest, BassServiceProto.Bas0260U01LoadDepartmentTypeResponse> {

	private static final Log LOGGER = LogFactory.getLog(Bas0260U01LoadDepartmentTypeHandler.class);

	@Resource
	private Bas0102Repository bas0102Repository;

	@Override
	@Transactional(readOnly = true)
	public Bas0260U01LoadDepartmentTypeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			Bas0260U01LoadDepartmentTypeRequest request) throws Exception {
		BassServiceProto.Bas0260U01LoadDepartmentTypeResponse.Builder response = BassServiceProto.Bas0260U01LoadDepartmentTypeResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		//String language = getLanguage(vertx, sessionId);
		//Update BD: get language from client side 
		String language = request.getLanguage();
		List<LoadDepartmentTypeInfo> listDepartmentTypes = bas0102Repository.getDepartmentTypeInfo(hospCode, "BUSEO_GUBUN", language);
		if (!CollectionUtils.isEmpty(listDepartmentTypes)) {
			for (LoadDepartmentTypeInfo item : listDepartmentTypes) {
				BassModelProto.LoadDepartmentTypeInfo.Builder info = BassModelProto.LoadDepartmentTypeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListInfo(info);
			}
		}
		return response.build();
	}
}