package nta.med.kcck.api.rpc;

import nta.med.common.remoting.rpc.context.RpcSession;
import nta.med.core.infrastructure.socket.VertxSession;
import nta.med.kcck.api.rpc.proto.SystemServiceProto;

import java.util.List;

/**
 * @author dainguyen.
 */
public interface RpcApiSession extends RpcSession, VertxSession {
    String getLoginId();

    String getHospCode();

    String getLanguage();

    String getUserGroup();

    Integer getClisSmoId();

    void logout(boolean force);

    void login(String loginId, String hospCode, String language, String userGroup, Integer clisSmoId, List<SystemServiceProto.LoginRequest.Capability> capabilityList);

    boolean isAuthorized(String hospCode);

    /**
     *
     */
    void subscribePatient(String hospCode);

    void subscribeHospital(String hospCode);

    void subscribeBooking(String hospCode);

    void unsubscribePatient(String hospCode);

    void unsubscribeHospital(String hospCode);

    void unsubscribeBooking(String hospCode);

    boolean hasSubscribedPatient(String hospCode);

    boolean hasSubscribedHospital(String hospCode);

    boolean hasSubscribedBooking(String hospCode);

    boolean hasCapability(SystemServiceProto.LoginRequest.Capability capability);
}
