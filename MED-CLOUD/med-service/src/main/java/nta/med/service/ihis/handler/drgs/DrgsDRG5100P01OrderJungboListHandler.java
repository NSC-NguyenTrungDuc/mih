package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01OrderJungboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class DrgsDRG5100P01OrderJungboListHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01OrderJungboListRequest, DrgsServiceProto.DrgsDRG5100P01OrderJungboListResponse> {
    private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01OrderJungboListHandler.class);
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DrgsDRG5100P01OrderJungboListRequest request, Vertx vertx, String clientId, String sessionId) {
        if(!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null){
            return false;
        }
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DrgsDRG5100P01OrderJungboListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01OrderJungboListRequest request) throws Exception {
        List<DrgsDRG5100P01OrderJungboListItemInfo> listObject = drg2010Repository.getDrgsDRG5100P01OrderJungboListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
                request.getJubsuDate(), request.getDrgBunho());
        DrgsServiceProto.DrgsDRG5100P01OrderJungboListResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01OrderJungboListResponse.newBuilder();
        if (!CollectionUtils.isEmpty(listObject)) {
            for (DrgsDRG5100P01OrderJungboListItemInfo item : listObject) {
                DrgsModelProto.DrgsDRG5100P01OrderJungboListItemInfo.Builder info = DrgsModelProto.DrgsDRG5100P01OrderJungboListItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getSeq1())) {
                    info.setSeq1(item.getSeq1());
                }
                if (!StringUtils.isEmpty(item.getSeq2()) && !item.getSeq2().equals("SEQ_2")) {
                    info.setSeq2(item.getSeq2());
                }
                if (!StringUtils.isEmpty(item.getText1())) {
                    info.setText1(item.getText1());
                }
                if (!StringUtils.isEmpty(item.getText2()) && !item.getText2().equals("TEXT_2")) {
                    info.setText2(item.getText2());
                }
                if (!StringUtils.isEmpty(item.getText3()) && !item.getText2().equals("TEXT_3")) {
                    info.setText3(item.getText3());
                }
                if (!StringUtils.isEmpty(item.getRemark())) {
                    info.setRemark(item.getRemark());
                }
                if (!StringUtils.isEmpty(item.getBarDrgBunho())) {
                    info.setBarDrgBunho(item.getBarDrgBunho());
                }
                if (!StringUtils.isEmpty(item.getBunho())) {
                    info.setBunho(item.getBunho());
                }

                response.addOrderJungboList(info);
            }
        }
        return response.build();
    }
}
