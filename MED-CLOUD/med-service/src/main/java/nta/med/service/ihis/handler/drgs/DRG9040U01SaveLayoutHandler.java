package nta.med.service.ihis.handler.drgs;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.drg.Drg9040;
import nta.med.core.domain.drg.Drg9041;
import nta.med.core.domain.drg.Drg9042;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg9040Repository;
import nta.med.data.dao.medi.drg.Drg9041Repository;
import nta.med.data.dao.medi.drg.Drg9042Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto.*;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;
import java.util.Date;
import java.util.List;

@Service
@Scope("prototype")
@Transactional
public class DRG9040U01SaveLayoutHandler extends ScreenHandler<DrgsServiceProto.DRG9040U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG9040U01SaveLayoutHandler.class);
    @Resource
    private Drg9040Repository drg9040Repository;

    @Resource
    private Drg9041Repository drg9041Repository;

    @Resource
    private Drg9042Repository drg9042Repository;

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG9040U01SaveLayoutRequest request) throws Exception {
        String hospitalCode = getHospitalCode(vertx, sessionId);
        SystemServiceProto.UpdateResponse.Builder response = saveLayout(request, hospitalCode);
        if (!response.getResult()) {
            throw new ExecutionException(response.build());
        }
        return response.build();
    }

    public SystemServiceProto.UpdateResponse.Builder saveLayout(DrgsServiceProto.DRG9040U01SaveLayoutRequest request, String hospitalCode) {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        //Call 1
        List<DRG9040U01GrdOrderInfo> listOrderItem = request.getGrdOrderInfoList();
        if (!CollectionUtils.isEmpty(listOrderItem)) {
            for (DRG9040U01GrdOrderInfo item : listOrderItem) {
                if (item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                    Date jubsuDate = DateUtil.toDate(item.getJubsuDate(), DateUtil.PATTERN_YYMMDD);
                    Date orderDate = DateUtil.toDate(item.getOrderDate(), DateUtil.PATTERN_YYMMDD);
                    Double drgBunho = CommonUtils.parseDouble(item.getDrgBunho());
                    String retVal = drg9040Repository.DRG9040U01XSavePerformerCheckExitCase1(jubsuDate, orderDate, drgBunho, hospitalCode);
                    if (!StringUtils.isEmpty(retVal)) {
                        drg9040Repository.DRG9040U01XSavePerformerUpdateCase1(request.getUserId(), new Date(), item.getOrderRemark(), item.getDrgRemark(),
                                jubsuDate, orderDate, drgBunho, hospitalCode);
                    } else {
                        Drg9040 drg9040 = new Drg9040();
                        drg9040.setSysDate(new Date());
                        drg9040.setSysId(request.getUserId());
                        drg9040.setInOutGubun("I");
                        drg9040.setJubsuDate(jubsuDate);
                        drg9040.setOrderDate(orderDate);
                        drg9040.setDrgBunho(drgBunho);
                        drg9040.setBunho(item.getBunho());
                        drg9040.setInputDate(new Date());
                        drg9040.setInputUser(request.getUserId());
                        drg9040.setOrderRemark(item.getOrderRemark());
                        drg9040.setDrgRemark(item.getDrgRemark());
                        drg9040.setHospCode(hospitalCode);
                        drg9040Repository.save(drg9040);
                    }
                }
            }
        }

        //Call 2
        List<DRG9040U01GrdJUSAOrderListInfo> listJUSAOrderItem = request.getGrdJusaOrderInfoList();
        if (!CollectionUtils.isEmpty(listJUSAOrderItem)) {
            for (DRG9040U01GrdJUSAOrderListInfo item : listJUSAOrderItem) {
                Double fkocs = CommonUtils.parseDouble(item.getFkocs2003());
                if (item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                    String retVal = drg9042Repository.DRG9040U01XSavePerformerCheckExitCase2(fkocs, hospitalCode);
                    if (!StringUtils.isEmpty(retVal)) {
                        drg9042Repository.DRG9040U01XSavePerformerUpdateCase2(request.getUserId(), new Date(), item.getOrderRemark(), item.getDrgRemark(), fkocs, hospitalCode);
                    } else {
                        Drg9042 drg9042 = new Drg9042();
                        drg9042.setSysDate(new Date());
                        drg9042.setSysId(request.getUserId());
                        drg9042.setInOutGubun("I");
                        drg9042.setFkocs(fkocs);
                        drg9042.setBunho(item.getBunho());
                        drg9042.setInputDate(new Date());
                        drg9042.setInputUser(request.getUserId());
                        drg9042.setOrderRemark(item.getOrderRemark());
                        drg9042.setDrgRemark(item.getDrgRemark());
                        drg9042.setHospCode(hospitalCode);
                        drg9042Repository.save(drg9042);
                    }
                }
            }
        }

        //Call 3
        List<DRG9040U01GrdOrderListInfo> listOrderListItem = request.getGrdOrderListInfoList();
        if (!CollectionUtils.isEmpty(listOrderListItem)) {
            for (DRG9040U01GrdOrderListInfo item : listOrderListItem) {
                Double fkocs = CommonUtils.parseDouble(item.getFkocs2003());
                if (item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                    String retVal = drg9042Repository.DRG9040U01XSavePerformerCheckExitCase2(fkocs, hospitalCode);
                    if (!StringUtils.isEmpty(retVal)) {
                        drg9042Repository.DRG9040U01XSavePerformerUpdateCase2(request.getUserId(), new Date(), item.getOrderRemark(), item.getDrgRemark(), fkocs, hospitalCode);
                    }
                } else {
                    Drg9042 drg9042 = new Drg9042();
                    drg9042.setSysDate(new Date());
                    drg9042.setSysId(request.getUserId());
                    drg9042.setInOutGubun("I");
                    drg9042.setFkocs(fkocs);
                    drg9042.setBunho(item.getBunho());
                    drg9042.setInputDate(new Date());
                    drg9042.setInputUser(request.getUserId());
                    drg9042.setOrderRemark(item.getOrderRemark());
                    drg9042.setDrgRemark(item.getDrgRemark());
                    drg9042.setHospCode(hospitalCode);
                    drg9042Repository.save(drg9042);
                }
            }
        }

        //Call 4
        List<DRG9040U01GrdOrderOutInfo> listOrderOutItem = request.getGrdOrderOutInfoList();
        if (!CollectionUtils.isEmpty(listOrderOutItem)) {
            for (DRG9040U01GrdOrderOutInfo item : listOrderOutItem) {
                if (item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                    Date jubsuDate = DateUtil.toDate(item.getJubsuDate(), DateUtil.PATTERN_YYMMDD);
                    Date orderDate = DateUtil.toDate(item.getOrderDate(), DateUtil.PATTERN_YYMMDD);
                    Double drgBunho = CommonUtils.parseDouble(item.getDrgBunho());
                    String retVal = drg9040Repository.DRG9040U01XSavePerformerCheckExitCase4(jubsuDate, orderDate, drgBunho, hospitalCode);
                    if (!StringUtils.isEmpty(retVal)) {
                        drg9040Repository.DRG9040U01XSavePerformerUpdateCase4(request.getUserId(), new Date(), item.getOrderRemark(), item.getDrgRemark(),
                                jubsuDate, orderDate, drgBunho, hospitalCode);
                    } else {
                        Drg9040 drg9040 = new Drg9040();
                        drg9040.setSysDate(new Date());
                        drg9040.setSysId(request.getUserId());
                        drg9040.setInOutGubun("O");
                        drg9040.setJubsuDate(jubsuDate);
                        drg9040.setOrderDate(orderDate);
                        drg9040.setBunho(item.getBunho());
                        drg9040.setDrgBunho(drgBunho);
                        drg9040.setInputDate(new Date());
                        drg9040.setInputUser(request.getUserId());
                        drg9040.setOrderRemark(item.getOrderRemark());
                        drg9040.setDrgRemark(item.getDrgRemark());
                        drg9040.setHospCode(hospitalCode);
                        drg9040Repository.save(drg9040);
                    }
                }
            }
        }

        //Call 5
        List<DRG9040U01GrdOrderListOutInfo> listOrderListOutItem = request.getGrdOrderListOutInfoList();
        if (!CollectionUtils.isEmpty(listOrderListOutItem)) {
            for (DRG9040U01GrdOrderListOutInfo item : listOrderListOutItem) {
                Double fkocs = CommonUtils.parseDouble(item.getFkocs1003());
                if (item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                    String retVal = drg9042Repository.DRG9040U01XSavePerformerCheckExitCase5(fkocs, hospitalCode);
                    if (!StringUtils.isEmpty(retVal)) {
                        drg9042Repository.DRG9040U01XSavePerformerUpdateCase5(request.getUserId(), new Date(), item.getOrderRemark(), item.getDrgRemark(), fkocs, hospitalCode);
                    } else {
                        Drg9042 drg9042 = new Drg9042();
                        drg9042.setSysDate(new Date());
                        drg9042.setSysId(request.getUserId());
                        drg9042.setInOutGubun("O");
                        drg9042.setFkocs(fkocs);
                        drg9042.setBunho(item.getBunho());
                        drg9042.setInputDate(new Date());
                        drg9042.setInputUser(request.getUserId());
                        drg9042.setOrderRemark(item.getOrderRemark());
                        drg9042.setDrgRemark(item.getDrgRemark());
                        drg9042.setHospCode(hospitalCode);
                        drg9042Repository.save(drg9042);
                    }
                }
            }
        }

        String retVal = drg9041Repository.DRG9040U01XSavePerformerCheckExit(request.getBunho(), hospitalCode);
        if (!StringUtils.isEmpty(request.getDrg9041OcsRemark()) || !StringUtils.isEmpty(request.getDrg9041DrgRemark())) {
            if (!StringUtils.isEmpty(retVal)) {
                drg9041Repository.DRG9040U01XSavePerformerUpdate(request.getUserId(), new Date(), request.getDrg9041OcsRemark(), request.getDrg9041DrgRemark(), request.getBunho(), hospitalCode);
            } else {
                Drg9041 drg9041 = new Drg9041();
                drg9041.setSysDate(new Date());
                drg9041.setSysId(request.getUserId());
                drg9041.setBunho(request.getBunho());
                drg9041.setInputDate(new Date());
                drg9041.setInputUser(request.getUserId());
                drg9041.setOrderRemark(request.getDrg9041OcsRemark());
                drg9041.setDrgRemark(request.getDrg9041DrgRemark());
                drg9041.setHospCode(hospitalCode);
                drg9041Repository.save(drg9041);
            }
        } else {
            if (!StringUtils.isEmpty(retVal)) {
                drg9041Repository.DRG9040U01XSavePerformerDelete(request.getBunho(), hospitalCode);
            }
        }
        response.setResult(true);
        return response;
    }
}
