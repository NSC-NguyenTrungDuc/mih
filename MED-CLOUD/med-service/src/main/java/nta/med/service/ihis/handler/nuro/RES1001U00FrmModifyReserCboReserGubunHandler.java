package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class RES1001U00FrmModifyReserCboReserGubunHandler extends ScreenHandler<NuroServiceProto.RES1001U00FrmModifyReserCboReserGubunRequest, NuroServiceProto.RES1001U00FrmModifyReserCboReserGubunResponse> {
		private static final Log LOG = LogFactory.getLog(RES1001U00FrmModifyReserCboReserGubunHandler.class);
		
		@Resource
		private Bas0102Repository bas0102Repository;

		@Override
		@Transactional(readOnly = true)
		public NuroServiceProto.RES1001U00FrmModifyReserCboReserGubunResponse handle(Vertx vertx, String clientId,
				String sessionId, long contextId,
				NuroServiceProto.RES1001U00FrmModifyReserCboReserGubunRequest request) throws Exception {
			NuroServiceProto.RES1001U00FrmModifyReserCboReserGubunResponse.Builder response = NuroServiceProto.RES1001U00FrmModifyReserCboReserGubunResponse.newBuilder();
			List<ComboListItemInfo> listItem = bas0102Repository.getComboListItemInfoByCodeType(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "RESER_GUBUN");
        	if (!CollectionUtils.isEmpty(listItem)) {
            	 for (ComboListItemInfo item : listItem) {
            		 CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
            		 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
            		 response.addCboReserGubunInfo(info);
                 }
        	}
			return response.build();
		}
}
